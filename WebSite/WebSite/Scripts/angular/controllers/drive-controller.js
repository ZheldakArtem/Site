angular.module('main', ['systemService'])
.controller('drive-controller', [
    '$scope', 'system-service',
function ($scope, service) {

    function getSubItems() {


    }

    function init() {
        service.getDrives().then(function (response) {
            $scope.Drives = [];
          
            response.data.forEach(function (element, index, array) {
                $scope.Drives.push(element);
            });
        });
    }
    init();
}]);