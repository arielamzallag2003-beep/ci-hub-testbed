"""Trivial Python module. The hub runs CodeQL and hygiene over it, not a build."""


def normalise(values):
    return [v.strip().lower() for v in values if v and v.strip()]


if __name__ == "__main__":
    print(normalise([" Alpha ", "", "BETA "]))
