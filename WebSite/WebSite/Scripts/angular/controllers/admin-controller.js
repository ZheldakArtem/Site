(function () {
    angular.module('adminApp', ['adminServiceModule'])
    .controller('admin-controller', [
        '$scope', 'admin-service',
     function ($scope, service) {

         $scope.editPlace = false;
         $scope.newRole = false;
         $scope.editUser = {};

         $scope.showEditPlace = function (user) {
             $scope.editPlace = true;
             $scope.editUser.name = user.name;
         };

         $scope.editRole = function (role) {
             $scope.editUser.role = role;

             service.editUserRole($scope.editUser).then(function () {
                 alert('Operation was completed.');
                 getUsers();
                 //$scope.users[index].role = role;
             },
             function () {
                 alert('The role has not been changed.');
                 $scope.editPlace = false;
             });
         }

         $scope.createRole = function (newRole) {
             service.addRole(newRole).then(function () {
                 alert('The role was created.');
                 $scope.newRole = false;
                 getRoles();
             },
             function () {
                 alert('The role was\'t created.');
                 $scope.newRole = false;
             });
         }

         function init() {
             getUsers();
             getRoles();
         }

         var getUsers = function () {
             service.getUsers().then(function (response) {
                 $scope.users = [];
                 response.data.forEach(function (element, index, array) {
                     $scope.users.push(element);
                 });
             });
         }

         var getRoles = function () {
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