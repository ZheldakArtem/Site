(function () {
    angular.module('systemServiceModule', []).
        factory('system-service', ['$http', function ($http) {
            return {
                getDrives: function () {
                    return $http.get(urlSystem);
                },
                getFolders: function (path) {
                    return $http.get(urlSystem + 'GetFolders?path=' + path);
                },
                getFiles: function (path) {
                    return $http.get(urlSystem + 'GetFiles?path=' + path);
                },
                deleteFolder: function (path) {
                    return $http.delete(urlSystem + 'DeleteFolder?path=' + path);
                },
                deleteFile: function (path) {
                    return $http.delete(urlSystem + 'DeleteFile?path=' + path);
                },
                createFolder: function (path, name) {
                    return $http.post(urlSystem + 'CreateFolder?path=' + path + '&name=' + name);
                },
                createFile: function (path, name) {
                    return $http.post(urlSystem + 'CreateFile?path=' + path + '&name=' + name);
                }
            }
        }]);
}());