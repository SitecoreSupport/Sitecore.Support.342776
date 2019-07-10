using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.XA.Foundation.Multisite.Pipelines.PushCloneChanges;

namespace Sitecore.Support.XA.Foundation.Multisite.Pipelines.PushCloneChanges
{
    public class PushPropertyChanges : PushCloneChangesProcessorBase
    {
        public override void Process(PushCloneChangesArgs args)
        {
            Dictionary<string, PropertyChange> propertyChanges = args.Changes.Properties;
            var keys = propertyChanges.Keys;
            var values = propertyChanges.Values;
            foreach (var key in propertyChanges.Keys)
            {
                if (key.ToLower().Equals("templateid"))
                {
                    args.Clone.Editing.BeginEdit();
                    args.Clone.TemplateID = (ID)propertyChanges[key].Value;
                    args.Clone.Editing.EndEdit();
                }
            }
        }
    }
}