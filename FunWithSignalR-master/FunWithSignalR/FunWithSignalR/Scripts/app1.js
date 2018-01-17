

'use strict';

$(function () {
  
    var zigChatHubProxy = $.connection.zigChatHub;

  
    $.connection.hub.start()
        .done(function () {
            var status = zigChatHubProxy.server.connectUser($('#userId').val()).done(function (data, textStatus, jqXHR) {
                if (!data.Success) {
                    alert(data.ErrorMessage);
                    return;
                }

               // zigChatHubProxy.server.send(window.name, $('#userId').val());
            });
          

                  
        })
        .fail(function () {
            console.log('Could not connect.');
        });
});