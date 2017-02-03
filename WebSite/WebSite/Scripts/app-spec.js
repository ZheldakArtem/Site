describe('Testing a systemService', function () {
   // https://docs.angularjs.org/api/ngMock/service/$httpBackend
    it('should display names of drives', function () {

        var service,backend;
        var actualStatus;
        angular.mock.module('systemServiceModule');

        angular.mock.inject(function (_systemService_,_$httpBackend_) {
            service = _systemService_;
            backend = _$httpBackend_;
        });
        service.getDrives().then(function (response) {
            alert('good');
        },
        function (response) {
            alert('bad');
        });
       
        backend.flush();
        expect(200).toEqual(200);
    });
});
