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
        ErrorBorder.IsVisible = false;

        if (_isRegisterMode)
        {
            TitleTextBlock.Text = "Create Account";
            SubtitleTextBlock.Text = "Fill in your details to create an account";
            ActionButtonText.Text = "CREATE ACCOUNT";

            EmailField.IsVisible = true;
            ConfirmPasswordField.IsVisible = true;

            RegisterTabBtn.Background = Brush.Parse("#161B2E");
            RegisterTabBtn.Foreground = Brush.Parse("#00F0FF");
            SignInTabBtn.Background = Brushes.Transparent;
            SignInTabBtn.Foreground = Brush.Parse("#656F84");
        }
        else
        {
            TitleTextBlock.Text = "Sign In";
            SubtitleTextBlock.Text = "Enter your username and password to continue";
            ActionButtonText.Text = "SIGN IN";

            EmailField.IsVisible = false;
            ConfirmPasswordField.IsVisible = false;

            SignInTabBtn.Background = Brush.Parse("#161B2E");
            SignInTabBtn.Foreground = Brush.Parse("#00F0FF");
            RegisterTabBtn.Background = Brushes.Transparent;
            RegisterTabBtn.Foreground = Brush.Parse("#656F84");
        }
    }

    private void OnActionButtonClick(object? sender, RoutedEventArgs e)
    {
        string username = UsernameTextBox.Text?.Trim() ?? string.Empty;
        string password = PasswordTextBox.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            ShowError("Please fill in both username and password.");
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

            ErrorBorder.IsVisible = false;
        }
        else
        {
            ErrorBorder.IsVisible = false;
        }
    }

    private void ShowError(string message)
    {
        ErrorTextBlock.Text = message;
        ErrorBorder.IsVisible = true;
    }
}