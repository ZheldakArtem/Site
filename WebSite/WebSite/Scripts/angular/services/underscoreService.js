(function () {
    var underscore = angular.module('underscoreService', []);
    underscore.service('_', ['$window', function ($window) {
        var temp = $window._;
        return $window._;
    }]);
})();
