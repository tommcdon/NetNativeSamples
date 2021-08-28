#include "pch.h"
#include "MainPage.h"
#include "MainPage.g.cpp"

#include <winstring.h>
#include <sstream>


using namespace winrt;
using namespace Windows::UI::Xaml;

namespace winrt::CPPWinRTCSharpV2::implementation
{
    MainPage::MainPage()
    {
        InitializeComponent();
    }

    int32_t MainPage::MyProperty()
    {
        throw hresult_not_implemented();
    }

    void MainPage::MyProperty(int32_t /* value */)
    {
        throw hresult_not_implemented();
    }

    void MainPage::ClickHandler(IInspectable const&, RoutedEventArgs const&)
    {
        //myButton().Content(box_value(L"Clicked"));

        hstring myString = class1.GetMyString();

        myButton().Content(box_value(myString));

        com_array<hstring> foo = class1.GetJsonStuff();

        std::wostringstream wostringstream;
        for (hstring foostr : foo)
        {
            wostringstream << foostr.c_str() << std::endl;
        }
        myText().Text(wostringstream.str());

    }
}
