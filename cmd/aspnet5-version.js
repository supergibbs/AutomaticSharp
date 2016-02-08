var jsonfile = require('jsonfile');
var semver = require('semver');

var file = '../src/AutomaticSharp/project.json';
var semversion;

if (process.env.APPVEYOR_REPO_TAG === 'true') {
    semversion = process.env.APPVEYOR_REPO_TAG_NAME.substring(1);
} else {
    var buildVersion = process.env.APPVEYOR_BUILD_VERSION.substring(1);
    var findPoint = buildVersion.lastIndexOf(".");
    var basePackageVer = buildVersion.substring(0, findPoint);
    var buildNumber = buildVersion.substring(findPoint + 1, buildVersion.length);
    semversion = semver.valid(basePackageVer + '-CI' + buildNumber);
}

jsonfile.readFile(file, function(err, project) {
    project.version = semversion;
    jsonfile.writeFile(file, project, { spaces: 2 }, function(err) {
        console.error(err);
    });
});