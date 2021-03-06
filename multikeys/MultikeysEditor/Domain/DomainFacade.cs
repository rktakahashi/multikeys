﻿using MultikeysEditor.Domain.Layout;
using MultikeysEditor.Model;
using MultikeysEditor.Persistence;
using System.Threading.Tasks;

namespace MultikeysEditor.Domain
{
    /// <summary>
    /// Implementation of the domain facade.
    /// </summary>
    class DomainFacade : IDomainFacade
    {
        /// <throws>XmlSchemValidationException</throws>
        public MultikeysLayout LoadLayout(string path)
        {
            return XmlPersistence.Load(path);
        }

        public void SaveLayout(MultikeysLayout model, string path)
        {
            // TODO: Apply validation rules, such as not allowing a <keyboard> without <layer>s.
            XmlPersistence.Save(model, path);
        }

        public IPhysicalLayout GetPhysicalLayout(PhysicalLayoutStandard standard)
        {
            return PhysicalLayoutFactory.FromStandard(standard);
        }

        async public Task<string> DetectKeyboardUniqueName()
        {
            return await RawInput.RawKeyboard.DetectKeyboardName();
        }
    }
}
