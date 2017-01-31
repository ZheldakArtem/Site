(function () {
    angular.module('adminServiceModule',[])
    .service('admin-service', ['$http', function ($http) {
        return {
            getUsers: function () {
                return $http.get(urlAdmin + 'GetUsers');
            },
            getRoles: function () {
                return $http.get(urlAdmin + 'api/Admin/GetRoles');
            },
            addRole: function (nameRole) {
                return $http.post(urlAdmin + 'CreateRole?name=' + nameRole);
            },
            editUserRole: function (newInfo) {
                return $http.put(urlAdmin + 'EditRoleForUser?=userName=' + newInfo.user + '&roleName=' + newInfo.role);
            }
        };
    }]);
}());