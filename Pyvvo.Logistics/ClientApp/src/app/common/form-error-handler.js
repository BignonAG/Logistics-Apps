"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var FormErrorHandler = /** @class */ (function () {
    function FormErrorHandler(_fg) {
        this.formGroup = _fg;
    }
    FormErrorHandler.prototype.hasError = function (controlName, errorName) {
        return this.formGroup.controls[controlName].hasError(errorName);
    };
    return FormErrorHandler;
}());
exports.FormErrorHandler = FormErrorHandler;
//# sourceMappingURL=form-error-handler.js.map