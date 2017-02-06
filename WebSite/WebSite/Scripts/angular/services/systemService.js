(function () {
    angular.module('systemServiceModule', []).
        factory('systemService', function ($http) {
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
                createFolder: function (data) {
                    return $http.post(urlSystem + 'CreateFolder', data);
                },
                createFile: function (data) {
                    return $http.post(urlSystem + 'CreateFile', data);
                }
            }
        });
}());