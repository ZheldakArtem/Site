angular.module('systemService', []).
service('system-service', ['$http', function ($http) {
    return {
        getDrives: function () {
            return $http.get('api/system');
        },
        getFolders: function (path) {
            return $http.get('api/system/GetFolders?path=' + path);
        },
        getFiles: function (path) {
            return $http.get('api/system/GetFiles?path=' + path);
        },
        deleteFolder: function (path) {
            return $http.delete('api/system/DeleteFolder?path=' + path);
        },
        deleteFile: function (path) {
            return $http.delete('api/system/DeleteFile?path=' + path);
        },
        createFolder: function (path, name) {
            return $http.post('api/system/CreateFolder?path=' + path + '&name=' + name);
        },
        createFile: function (path, name) {
            return $http.post('api/system/CreateFile?path=' + path + '&name=' + name);
        }
    }
}]);