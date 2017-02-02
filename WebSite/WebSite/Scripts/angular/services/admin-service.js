(function () {
    angular.module('adminServiceModule',[])
    .factory('admin-service', ['$http', function ($http) {
        return {
            getUsers: function () {
                return $http.get(urlAdmin + 'GetUsers');
            },
            getRoles: function () {
                return $http.get(urlAdmin + 'GetRoles');
            },
            addRole: function (nameRole) {
                return $http.post(urlAdmin + 'CreateRole?name=' + nameRole);
            },
            editUserRole: function (newInfo) {
                return $http.put(urlAdmin + 'EditRoleForUser?userName=' + newInfo.name + '&roleName=' + newInfo.role);
            }
        };
    }]);
}());