# MAUI Development Team Onboarding Guide

## Quick Start Checklist

### Prerequisites Setup ✅
- [ ] Install Visual Studio 2022 or Visual Studio Code
- [ ] Install .NET 9.0 SDK
- [ ] Install MAUI workload: `dotnet workload install maui`
- [ ] Install Xcode (macOS only) - latest stable version
- [ ] Install Android Studio (for Android emulators)
- [ ] Configure Git with your credentials

### Repository Access ✅
- [ ] Request access to `eddyolk-github/MauiApp1` repository
- [ ] Clone repository: `git clone https://github.com/eddyolk-github/MauiApp1.git`
- [ ] Install pre-commit hooks: `cp .githooks/pre-commit .git/hooks/`
- [ ] Test build: `dotnet build MauiApp1/MauiApp1.csproj`

### Development Environment ✅
- [ ] Set up Android emulator for testing
- [ ] Configure iOS simulator (macOS only)
- [ ] Install recommended VS Code extensions (see below)
- [ ] Configure code formatting settings
- [ ] Join team Slack channels: #dev-team, #alerts, #releases

## Git Workflow for New Developers

### Your First Contribution

1. **Understand the Branching Model**
   ```
   main (production) ← release/v1.x.x ← develop ← feature/your-feature
   ```

2. **Start a New Feature**
   ```bash
   # Always start from develop
   git checkout develop
   git pull origin develop
   
   # Create your feature branch
   git checkout -b feature/add-settings-page
   
   # Make your changes
   # ... code, code, code ...
   
   # Commit with conventional commits
   git add .
   git commit -m "feat: add user settings page with theme toggle"
   
   # Push and create Pull Request
   git push -u origin feature/add-settings-page
   ```

3. **Pull Request Guidelines**
   - Target branch: `develop` (not main!)
   - Title format: `feat: add user settings page`
   - Include description of changes
   - Add screenshots for UI changes
   - Request review from team lead

### Daily Development Workflow

```bash
# Start of day - sync with team
git checkout develop
git pull origin develop

# If working on existing feature
git checkout feature/your-feature
git merge develop  # or rebase if you prefer

# End of day - push your work
git add .
git commit -m "wip: settings page layout complete"
git push origin feature/your-feature
```

## Code Standards & Best Practices

### C# Coding Standards
```csharp
// ✅ Good: Follow PascalCase for public members
public class UserService
{
    public async Task<User> GetUserAsync(int userId)
    {
        // Implementation
    }
}

// ✅ Good: Use meaningful names
var userRepository = new UserRepository();
var activeUser = await userRepository.GetActiveUserAsync();

// ❌ Bad: Unclear names
var repo = new UserRepository();
var u = await repo.GetAsync();
```

### XAML Standards
```xml
<!-- ✅ Good: Consistent indentation and naming -->
<ContentPage x:Class="MauiApp1.Views.SettingsPage"
             Title="Settings">
    <StackLayout Padding="20">
        <Label Text="User Preferences" 
               FontSize="Large"
               FontAttributes="Bold" />
        <Switch x:Name="DarkModeSwitch"
                IsToggled="{Binding IsDarkModeEnabled}" />
    </StackLayout>
</ContentPage>
```

### Commit Message Format
```bash
# Format: type(scope): description
feat(auth): add biometric authentication
fix(ui): resolve button alignment on Android
docs(readme): update setup instructions
test(user): add unit tests for user service
refactor(data): simplify API response models
```

## Testing Strategy

### Test Categories
1. **Unit Tests** (Required for all new code)
   ```csharp
   [Fact]
   public async Task GetUserAsync_ValidId_ReturnsUser()
   {
       // Arrange
       var userId = 123;
       var expectedUser = new User { Id = userId };
       
       // Act
       var result = await userService.GetUserAsync(userId);
       
       // Assert
       Assert.Equal(expectedUser.Id, result.Id);
   }
   ```

2. **Integration Tests** (For API endpoints)
3. **UI Tests** (For critical user flows)

### Running Tests Locally
```bash
# Run all tests
dotnet test

# Run specific test class
dotnet test --filter "ClassName=UserServiceTests"

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## Common Development Tasks

### Adding a New Page
1. Create XAML page in `Views/` folder
2. Create corresponding ViewModel in `ViewModels/`
3. Register page in `MauiProgram.cs`
4. Add navigation route in `AppShell.xaml`
5. Write unit tests for ViewModel logic

### Adding Platform-Specific Code
```csharp
// Use conditional compilation
#if ANDROID
    // Android-specific code
#elif IOS
    // iOS-specific code
#elif MACCATALYST
    // macOS-specific code
#endif
```

### Debugging Tips
- Use `Debug.WriteLine()` for quick debugging
- Set breakpoints in shared code
- Use platform-specific debugging tools
- Check device logs for native crashes

## CI/CD Pipeline Understanding

### What Happens on Push
1. **Feature Branch Push**:
   - Triggers build validation
   - Runs unit tests
   - Reports coverage
   - No deployment

2. **Develop Branch Push**:
   - Full test suite
   - Builds all platforms
   - Deploys to staging environment
   - Notifies team in Slack

3. **Main Branch Push**:
   - Full test suite
   - Builds release versions
   - Requires manual approval
   - Deploys to production

### Monitoring Your Changes
- Check GitHub Actions tab for build status
- Monitor Slack #alerts for any issues
- Use Firebase App Distribution for testing
- Review crash reports in App Center

## Troubleshooting Common Issues

### Build Failures
```bash
# Clean and rebuild
dotnet clean
dotnet restore
dotnet build

# Clear NuGet cache
dotnet nuget locals all --clear

# Reinstall MAUI workload
dotnet workload uninstall maui
dotnet workload install maui
```

### Platform-Specific Issues
- **Android**: Check SDK versions, emulator state
- **iOS**: Verify Xcode version, provisioning profiles
- **macOS**: Ensure Xcode command line tools installed

### Git Issues
```bash
# Sync fork with upstream
git fetch origin
git checkout develop
git reset --hard origin/develop

# Resolve merge conflicts
git mergetool
# Or use VS Code's built-in merge editor
```

## Team Communication

### Channels
- **#dev-team**: Daily development discussions
- **#alerts**: CI/CD notifications, build failures
- **#releases**: Release announcements and planning
- **#random**: Non-work discussions

### Meetings
- **Daily Standup**: 9 AM PST (15 minutes)
- **Sprint Planning**: Every 2 weeks
- **Retrospectives**: End of each sprint
- **Architecture Reviews**: As needed

### Getting Help
1. Search existing GitHub issues
2. Ask in #dev-team Slack channel
3. Schedule pairing session with senior developer
4. Escalate to team lead if blocked

## Resources

### Documentation
- [MAUI Official Docs](https://docs.microsoft.com/en-us/dotnet/maui/)
- [Git Flow Guide](./GIT_WORKFLOWS.md)
- [Deployment Strategy](./DEPLOYMENT_STRATEGY.md)

### Tools
- **Visual Studio Code Extensions**:
  - C# Dev Kit
  - .NET MAUI Extension Pack
  - GitLens
  - Thunder Client (API testing)
  
- **Recommended Apps**:
  - GitHub Desktop (for Git GUI)
  - Postman (API testing)
  - Android Studio (Android development)
  - Xcode (iOS development)