angular.module('main', ['systemService'])
.controller('drive-controller', [
    '$scope', 'system-service',
function ($scope, service) {

    $scope.Drives = [];
    init();

    $scope.getSubItems = function (path) {
        $scope.Files = [];
        $scope.Folders = [];
        service.getFiles(path).then(function (response) {

            response.data.forEach(function (element, index, array) {

                $scope.Files.push(element);
            });
        });

        service.getFolders(path).then(function (response) {
            response.data.forEach(function (element, index, array) {
                $scope.Folders.push(element);
            });
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

}]);