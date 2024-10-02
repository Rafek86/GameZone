$.validator.addMethod('filesize', function (value, element, param) {
    // Check if file is provided or if field is optional, then check the file size
    var isValid = this.optional(element) || (element.files[0].size <= param);
    return isValid;
}); 