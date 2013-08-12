'user strict';

angular.module('whiteBoard.directives', ['whiteBoard.services'])
    .directive('upload', ['uploadManager', function (uploadManager) {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                $(element).fileupload({
                    dataType: 'text',
                    add: function (e, data) {
                        uploadManager.add(data);
                    },
                    progressall: function (e, data) {
                        var progress = parseInt(data.loaded / data.total * 100, 10);
                        uploadManager.setProgress(progress);
                    },
                    done: function (e, data) {
                        uploadManager.setProgress(0);
                        uploadManager.setUploadedFile(data.files[0].name);
                    }
                });
            }
        };
    } ]);
