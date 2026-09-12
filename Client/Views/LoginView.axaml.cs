using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Client.Views;

public partial class LoginView : UserControl
{
    private bool _isRegisterMode = false;

    public LoginView()
    {
        InitializeComponent();
    }

    private void OnSignInTabClick(object? sender, RoutedEventArgs e) => SetMode(false);

    private void OnRegisterTabClick(object? sender, RoutedEventArgs e) => SetMode(true);

    private void SetMode(bool isRegister)
    {
        _isRegisterMode = isRegister;
        ErrorTextBlock.IsVisible = false;

        if (_isRegisterMode)
        {
            TitleTextBlock.Text = "Create Account";
            SubtitleTextBlock.Text = "Join Remote Connect to get started";
            ActionButton.Content = "Create Account";

            EmailField.IsVisible = true;
            ConfirmPasswordField.IsVisible = true;

            RegisterTabBtn.Background = Brush.Parse("#1F2333");
            RegisterTabBtn.Foreground = Brush.Parse("#FFFFFF");
            SignInTabBtn.Background = Brushes.Transparent;
            SignInTabBtn.Foreground = Brush.Parse("#6C7284");
        }
        else
        {
            TitleTextBlock.Text = "Welcome back";
            SubtitleTextBlock.Text = "Please enter your credentials to continue";
            ActionButton.Content = "Sign In";

            EmailField.IsVisible = false;
            ConfirmPasswordField.IsVisible = false;

            SignInTabBtn.Background = Brush.Parse("#1F2333");
            SignInTabBtn.Foreground = Brush.Parse("#FFFFFF");
            RegisterTabBtn.Background = Brushes.Transparent;
            RegisterTabBtn.Foreground = Brush.Parse("#6C7284");
        }
    }

    private void OnActionButtonClick(object? sender, RoutedEventArgs e)
    {
        string username = UsernameTextBox.Text?.Trim() ?? string.Empty;
        string password = PasswordTextBox.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            ShowError("Please fill in all required fields.");
            return;
        }

        if (_isRegisterMode)
        {
            string email = EmailTextBox.Text?.Trim() ?? string.Empty;
            string confirm = ConfirmPasswordTextBox.Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            {
                ShowError("Please enter a valid email address.");
                return;
            }

            if (password != confirm)
            {
                ShowError("Passwords do not match.");
                return;
            }

            // TODO: Execute registration logic
            ErrorTextBlock.IsVisible = false;
        }
        else
        {
            // TODO: Execute authentication logic
            ErrorTextBlock.IsVisible = false;
        }
    }

    private void ShowError(string message)
    {
        ErrorTextBlock.Text = message;
        ErrorTextBlock.IsVisible = true;
    }
}