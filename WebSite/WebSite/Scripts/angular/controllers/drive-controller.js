angular.module('main', ['systemService'])
.controller('drive-controller', [
    '$scope', 'system-service',
function ($scope, service) {

    $scope.Drives = [];

    $scope.getSubItems = function (path) {

        service.getFiles(path).then(function (response) {
            response.data.forEach(function (element, index, array) {
                $scope.Files = [];
                $scope.Files.push(element);
            });
        });

        service.getFolders(path).then(function (response) {
            $scope.Folders = [];
            response.data.forEach(function (element, index, array) {
                $scope.Folders.push(element);
            });
        }, function () {
            alert("Not access!!!");
        });
    }

    $scope.deleteFolder = function (path) {
        service.deleteFolder(path).then(function () {

        }, function () {
            alert("Not access!!!");
        });
    }

    $scope.deleteFile = function (path) {
        service.deleteFile(path).then(function () {

        }, function () {
            alert("Not access!!!");
        });
    }

    function init() {
        service.getDrives().then(function (response) {
            response.data.forEach(function (element, index, array) {
                $scope.Drives.push(element);
            });
        });
    }
    init();
}]);