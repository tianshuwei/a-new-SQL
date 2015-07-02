# (c) 2012 Darius Bacon
# Licensed under the GNU General Public Licence version 3
import re

def _memo(f):
    memos = {}
    def memoized(*args):
        try: return memos[args]
        except KeyError:
            result = memos[args] = f(*args)
            return result
    return memoized

_identifier = r'[A-Za-z_]\w*'

def Parser(grammar, **actions):
    parts = re.split(' ('+_identifier+') += ',
                     ' '+re.sub(r'\s', ' ', grammar))
    if len(parts) == 1 or parts[0].strip():
        raise BadGrammar("Missing left hand side", parts[0])
    if len(set(parts[1::2])) != len(parts[1::2]):
        raise BadGrammar("Multiply-defined rule(s)", grammar)
    rules = dict((lhs, [alt.split() for alt in (' '+rhs+' ').split(' | ')])
                 for lhs, rhs in zip(parts[1::2], parts[2::2]))
    return lambda text, rule=parts[1]: _parse(rules, actions, rule, text)

class BadGrammar(Exception):
    "A peglet grammar was ill-formed."

class Unparsable(Exception):
    "An attempted parse failed because the input did not match the grammar."

def _parse(rules, actions, rule, text):
    @_memo
    def parse_rule(name, pos):
        farthest = pos
        for alternative in rules[name]:
            pos1, vals1 = pos, ()
            for token in alternative:
                far, pos1, vals1 = parse_token(token, pos1, vals1)
                farthest = max(farthest, far)
                if pos1 is None: break
            else: return farthest, pos1, vals1
        return farthest, None, ()

    def parse_token(token, pos, vals):
        if re.match(r'!.', token):
            _, pos1, _ = parse_token(token[1:], pos, vals)
            return pos, pos if pos1 is None else None, vals
        elif token in rules:
            far, pos1, vals1 = parse_rule(token, pos)
            return far, pos1, pos1 is not None and vals + vals1
        elif token in actions:
            f = actions[token]
            if hasattr(f, 'peglet_action'): return f(text, pos, vals) 
            else: return pos, pos, (f(*vals),)
        else:
            if re.match(_identifier+'$', token):
                raise BadGrammar("Missing rule", token)
            if re.match(r'/.+/$', token): token = token[1:-1]
            m = re.match(token, text[pos:])
            if m: return pos + m.end(), pos + m.end(), vals + m.groups()
            else: return pos, None, ()

    far, pos, vals = parse_rule(rule, 0)
    if pos is None: raise Unparsable(rule, text[:far], text[far:])
    else: return vals

def attempt(parser, *args, **kwargs):
    "Call a parser, but return None on failure instead of raising Unparsable."
    try: return parser(*args, **kwargs)
    except Unparsable: return None

def OneResult(parser):
    "Parse like parser, but return exactly one result, not a tuple."
    def parse(text):
        results = parser(text)
        assert len(results) == 1, "Expected one result but got %r" % (results,)
        return results[0]
    return parse

def hug(*xs):
    "Return a tuple of all the arguments."
    return xs

def join(*strs):
    "Return all the arguments (strings) concatenated into one string."
    return ''.join(strs)

def position(text, pos, vals):
    "A peglet action: always succeed, producing the current position."
    return pos, pos, vals + (pos,)
position.peglet_action = True
