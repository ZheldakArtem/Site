﻿(function () {
    angular.module('main', ['systemServiceModule', 'underscoreService'])
    .controller('systemController', [
        '$scope', 'systemService', '_',
    function ($scope, service, _) {

        $scope.arrFullPath = [];
        $scope.drives = [];

        $scope.getSubItems = function (path, index) {
            $scope.currentPath = path;
            $scope.arrFullPath.push(path);

            if (typeof index !== 'undefined') {
                deleteNavElem(index);
            }
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
                service.createFolder({ Name: name, Path: $scope.currentPath }).then(function (result) {
                    var temp = result;
                    $scope.Folders.push($scope.currentPath + '\\' + name);
                },
                function () {
                    alert('Creation folder error.');
                });
            } else {
                service.createFile({ Name: name, Path: $scope.currentPath }).then(function () {
                    $scope.Files.push($scope.currentPath + '\\' + name);
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

        $scope.driveNamesFilter = function (arrayOfNames) {

            var result = [];
            for (var i = 0; i < arrayOfNames.length; i++) {
                result.push(arrayOfNames[i].charAt(0));
            }
            return _.first(result);
        }

        $scope.elementNamesFilter = function (elemName) {
            var result = _.last(elemName.split('\\'));

            return result === "" ? elemName.charAt(0) : result;
        }

        $scope.resetNavArr = function (nameDrive) {
            $scope.arrFullPath = [];
            $scope.getSubItems(nameDrive);
        }

        var deleteNavElem = function (index) {
            $scope.arrFullPath.splice(index, $scope.arrFullPath.length - index - 1);
        }
    }]);
}())
