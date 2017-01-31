(function () {
    angular.module('adminApp', ['adminServiceModule'])
    .controller('admin-controller', [
        '$scope', 'admin-service',
     function ($scope, service) {

         $scope.editPlace = false;
         $scope.editUser = {};

         var showEditPlace = function (user) {
             $scope.showEditPlace = true;
             $scope.editUser.user = user;
         }

         var editRole = function (role) {
             $scope.editUser.role = role;

             service.editUserRole($scope.editUser).then(function () {
                 alert('Operation was completed.')
             },
             function () {
                 alert('The role has not been changed.');
             });
         }

         var createRole = function (newRole) {
             service.addRole().then(function () {
                 alert('The role was created.')
             },
             function () {
                 alert('The rolw was\'t created.');
             });
         }

         function init() {
             service.getUsers().then(function (response) {
                 $scope.users = [];
                 response.data.forEach(function (element, index, array) {
                     $scope.users.push(element);
                 });
             });

             service.getRoles().then(function (response) {
                 $scope.roles = [];
                 response.data.forEach(function (element, index, array) {
                     $scope.roles.push(element);
                 });
             });
         }

         init();
     }]);
}());