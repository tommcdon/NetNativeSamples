#pragma once

#include "MainPage.g.h"
#include "winrt/RuntimeComponent1.h"

namespace winrt::CPPWinRTCSharpV2::implementation
{
    struct MainPage : MainPageT<MainPage>
    {
        MainPage();

        winrt::RuntimeComponent1::Class1 class1;

        int32_t MyProperty();
        void MyProperty(int32_t value);

        void ClickHandler(Windows::Foundation::IInspectable const& sender, Windows::UI::Xaml::RoutedEventArgs const& args);
    };
}

namespace winrt::CPPWinRTCSharpV2::factory_implementation
{
    struct MainPage : MainPageT<MainPage, implementation::MainPage>
    {
    };
}
