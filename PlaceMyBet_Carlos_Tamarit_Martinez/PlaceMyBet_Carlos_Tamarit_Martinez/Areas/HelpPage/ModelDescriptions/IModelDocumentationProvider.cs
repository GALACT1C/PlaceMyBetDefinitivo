using System;
using System.Reflection;

namespace PlaceMyBet_Carlos_Tamarit_Martinez.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}