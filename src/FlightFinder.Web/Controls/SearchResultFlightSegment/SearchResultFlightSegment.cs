using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace FlightFinder.Web.Controls.SearchResultFlightSegment
{
    public class SearchResultFlightSegment : DotvvmMarkupControl
    {

        public string Symbol
        {
            get { return (string)GetValue(SymbolProperty); }
            set { SetValue(SymbolProperty, value); }
        }
        public static readonly DotvvmProperty SymbolProperty
            = DotvvmProperty.Register<string, SearchResultFlightSegment>(c => c.Symbol, null);

    }
}
