describe('Testing a drive-controller', function () {
    var $scope, ctr;
    var serviceMock;

    beforeEach(function () {

        serviceMock = jasmine.createSpyObj('admin-service', ['getDrives, getFolders, getFiles, deleteFolder, deletFile, createFolder, createFile']);
        module('main');

        inject(function ($rootScope, $controller, $q) {
            $scope = $rootScope.$new();
        });
    });

    it('should say hallo to the World', function () {
        expect('World').toEqual('World');
    });
});

