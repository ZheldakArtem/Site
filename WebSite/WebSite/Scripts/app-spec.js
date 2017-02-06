describe('Testing a systemService', function () {

    var service, $httpBackend, authRequestHandler;
    var $scope = {};

    beforeEach(angular.mock.module('systemServiceModule'));

    beforeEach(angular.mock.inject(function (_systemService_, _$httpBackend_) {
        service = _systemService_;
        $httpBackend = _$httpBackend_;
        authRequestHandler = authRequestHandler = $httpBackend.when('GET', urlSystem)
    }));

    afterEach(function () {
        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest();
    });

    it('Verify status code 200', function () {
        service.getDrives().then(function (responce) {
            $scope.status = responce.status;
        });

        $httpBackend.expectGET(urlSystem).respond(200);
        $httpBackend.flush();
        expect($scope.status).toEqual(200);
    });

    it('should fail', function () {
        service.getDrives().then(function (responce) {
            $scope.status = responce.status;
        }, function () {
            $scope.status = 'Failed...';
        });

        authRequestHandler.respond(401, '');

        $httpBackend.expectGET(urlSystem);

        $httpBackend.flush();
        expect($scope.status).toBe('Failed...');
    });



});
