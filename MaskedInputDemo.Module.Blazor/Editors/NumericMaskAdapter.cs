﻿using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskedInputDemo.Module.Blazor.Editors
{
    public class NumericMaskAdapter : ComponentAdapterBase
    {
        public NumericMaskAdapter(NumericMaskModel componentModel)
        {
            ComponentModel = componentModel ?? throw new ArgumentNullException(nameof(componentModel));
            ComponentModel.ValueChanged += ComponentModel_ValueChanged;
        }
        public NumericMaskModel ComponentModel { get; }
        public override void SetAllowEdit(bool allowEdit)
        {
            ComponentModel.ReadOnly = !allowEdit;
        }
        public override object GetValue()
        {
            return ComponentModel.Value;
        }
        public override void SetValue(object value)
        {
            ComponentModel.Value = (decimal)value;
        }
        protected override RenderFragment CreateComponent()
        {
            return ComponentModelObserver.Create(ComponentModel, NumericMaskRenderer.Create(ComponentModel));
        }
        private void ComponentModel_ValueChanged(object sender, EventArgs e) => RaiseValueChanged();
        public override void SetAllowNull(bool allowNull) { /* ...*/ }
        public override void SetDisplayFormat(string displayFormat) { /* ...*/ }
        public override void SetEditMask(string editMask) { /* ...*/ }
        public override void SetEditMaskType(EditMaskType editMaskType) { /* ...*/ }
        public override void SetErrorIcon(ImageInfo errorIcon) { /* ...*/ }
        public override void SetErrorMessage(string errorMessage) { /* ...*/ }
        public override void SetIsPassword(bool isPassword) { /* ...*/ }
        public override void SetMaxLength(int maxLength) { /* ...*/ }
        public override void SetNullText(string nullText) { /* ...*/ }
    }
}
