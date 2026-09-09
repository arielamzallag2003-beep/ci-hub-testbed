# Notes

A documentation file, so we can also test that a docs-only pull request
skips the build jobs.

## Docs-only test

This paragraph changes nothing but documentation. The hub should detect that
and skip every build job, keeping the run to about thirty seconds while still
reporting green.
