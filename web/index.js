// Node marker file. The hub runs CodeQL over this, not a build.
function slugify(text) {
  return String(text).trim().toLowerCase().replace(/[^a-z0-9]+/g, "-");
}

module.exports = { slugify };
