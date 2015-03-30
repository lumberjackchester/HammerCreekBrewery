function WhatsOnTapViewModel() {
    var self = this;
    self.Locations = ko.observable();
    self.GetData = function(response) {
        self.Locations(response);
    };
    self.Init = function() {
        $.get('json/WhatsOnTap.json', self.GetData);
    };
}