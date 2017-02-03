
angular.module('main', ['systemServiceModule'])
.controller('driveController', [
    '$scope', 'systemService',
function ($scope, service) {

    $scope.drives = [];

    $scope.getSubItems = function (path) {
        $scope.currentPath = path;
        service.getFiles(path).then(function (response) {
            $scope.Files = [];
            response.data.forEach(function (element, index, array) {
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

    $scope.deleteFolder = function (path, index) {
        if (!confirm("Are you shure?")) {
            return;
        }

        $scope.Folders.splice(index, 1);

        service.deleteFolder(path).then(function () {
            alert("success!!!");
        }, function () {
            alert("Not access!!!");
        });
    }

    $scope.deleteFile = function (path, index) {
        if (!confirm("Are you shure?")) {
            return;
        }

        $scope.Files.splice(index, 1);

        service.deleteFile(path).then(function () {
            alert("success!!!");
        }, function () {
            alert("Not access!!!");
        });
    }

    $scope.createItem = function (name) {
        if (typeof (name) === "undefined" || typeof (name) === null) {
            alert('The path is empty.');
            return;
        }
        if ($scope.createType === "folder") {
            service.createFolder($scope.currentPath, name).then(function (result) {
                var temp = result;
                $scope.Folders.push($scope.currentPath + name);
            },
            function () {
                alert('Creation folder error.');
            });
        } else {
            service.createFile($scope.currentPath, name).then(function () {
                $scope.Files.push($scope.currentPath + name);
            },
            function () {
                alert('Creation file error.');
            });
        }
    }

    service.getDrives().then(function (response) {
        response.data.forEach(function (element, index, array) {
            $scope.drives.push(element);
        });
    });
}]);
