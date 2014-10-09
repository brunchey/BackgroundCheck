
backgroundCheckApp
      .factory('applicantService', ['$http', function ($http) {

          var applicantSvc = {};

          applicantSvc.getApplicants = function () {
              return $http({
                  method: 'GET',
                  url: '../applicant'
              });
          }

          applicantSvc.getApplicantDetails = function (id) {
              return $http({
                  method: 'GET',
                  url: '../applicant/' + id
              });
          }

          applicantSvc.create = function (applicant) {
              return $http({
                  method: "POST",
                  url: '../applicant/',
                  data: applicant
              });
          }

          applicantSvc.update = function (applicant) {
              return $http({
                  method: "PUT",
                  url: '../applicant/' + applicant.Id,
                  data: applicant
              });
          }

          return applicantSvc;

      }]);
