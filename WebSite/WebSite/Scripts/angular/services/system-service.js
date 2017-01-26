angular.module('systemService', []).
service('system-service', ['$http', function ($http) {
    return {
        getDrives: function () {
            return $http.get('api/system');
        },
        getFolders: function (path) {
            return $http.get('api/system/?path'+path);
        }
    }
}]);