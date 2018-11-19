using System;
using System.Threading.Tasks;
using FlightFinder.BL.Models;
using Riganti.Selenium.Core.Abstractions;
using Riganti.Selenium.DotVVM;

namespace FlightFinder.Web.Tests.FlightSearch.SearchForm
{
    public class SearchFormControlObject : PageObjectBase
    {

        public IElementWrapper FromComboBox => GetControlByUiId("SearchFormFromAirport");
        public string From
        {
            get => GetComboBoxValue(FromComboBox);
            set => SetComboBoxValue(FromComboBox, value);
        }
        
        public IElementWrapper ToComboBox => GetControlByUiId("SearchFormToAirport");
        public string To
        {
            get => GetComboBoxValue(ToComboBox);
            set => SetComboBoxValue(ToComboBox, value);
        }

        public IElementWrapper DepartDatePicker => GetControlByUiId("SearchFormDepartDate");

        public DateTime Depart
        {
            get => GetDatePickerValue(DepartDatePicker);
            set => SetDatePickerValue(DepartDatePicker, value);
        }

        public IElementWrapper ReturnDatePicker => GetControlByUiId("SearchFormReturnDate");
        public DateTime Return
        {
            get => GetDatePickerValue(ReturnDatePicker);
            set => SetDatePickerValue(ReturnDatePicker, value);
        }

        public IElementWrapper TicketClassComboBox => GetControlByUiId("SearchFormTicketClasses");

        public TicketClassData TicketClass
        {
            //get => TicketClassData.Get(BL.Models.TicketClass.TryParse(GetComboBoxValue(TicketClassComboBox)));
            set => SetComboBoxValue(TicketClassComboBox, value.Name);
        }

        public SearchFormControlObject(IBrowserWrapper browser) : base(browser)
        {
        }

        public void Search()
        {
            var searchButton = GetControlByUiId("SearchFormSearch");

            searchButton.Click();

            browser.WaitForPostback();
        }
    }
}