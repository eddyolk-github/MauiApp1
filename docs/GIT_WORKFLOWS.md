# Git Configuration for MAUI Development Team

## Repository Rules (GitHub Settings)

### Branch Protection Rules

#### Main Branch Protection
```json
{
  "required_status_checks": {
    "strict": true,
    "checks": [
      "test",
      "build-matrix (android)",
      "build-matrix (ios)",
      "build-matrix (maccatalyst)"
    ]
  },
  "enforce_admins": true,
  "required_pull_request_reviews": {
    "required_approving_review_count": 2,
    "dismiss_stale_reviews": true,
    "require_code_owner_reviews": true
  },
  "restrictions": null,
  "allow_force_pushes": false,
  "allow_deletions": false
}
```

#### Develop Branch Protection
```json
{
  "required_status_checks": {
    "strict": true,
    "checks": ["test"]
  },
  "required_pull_request_reviews": {
    "required_approving_review_count": 1,
    "dismiss_stale_reviews": true
  },
  "allow_force_pushes": false
}
```

## Team Git Configuration

### Individual Developer Setup
```bash
# Configure Git for MAUI development
git config --global user.name "Your Name"
git config --global user.email "your.email@company.com"

# MAUI-specific configurations
git config --global core.autocrlf true  # Windows line endings
git config --global pull.rebase true    # Clean history
git config --global push.default simple # Safer pushing

# Enable helpful features
git config --global branch.autosetuprebase always
git config --global rerere.enabled true # Remember conflict resolutions
```

### Repository-specific Setup
```bash
# Clone and setup
git clone https://github.com/eddyolk-github/MauiApp1.git
cd MauiApp1

# Install pre-commit hooks
cp .githooks/pre-commit .git/hooks/
chmod +x .git/hooks/pre-commit

# Configure local settings
git config core.hooksPath .githooks
```

## Workflow Commands Reference

### Feature Development
```bash
# Start new feature from develop
git checkout develop
git pull origin develop
git checkout -b feature/user-authentication

# Work on feature
git add .
git commit -m "feat: add user login functionality"

# Push and create PR
git push -u origin feature/user-authentication
# Create PR: feature/user-authentication → develop
```

### Release Process
```bash
# Start release from develop
git checkout develop
git pull origin develop
git checkout -b release/v1.2.0

# Update version numbers in MauiApp1.csproj
# Test and fix any issues

# Merge to main
git checkout main
git merge --no-ff release/v1.2.0
git tag -a v1.2.0 -m "Release version 1.2.0"

# Merge back to develop
git checkout develop
git merge --no-ff release/v1.2.0

# Push everything
git push origin main
git push origin develop
git push origin v1.2.0

# Delete release branch
git branch -d release/v1.2.0
git push origin --delete release/v1.2.0
```

### Hotfix Process
```bash
# Start hotfix from main
git checkout main
git pull origin main
git checkout -b hotfix/critical-bug-fix

# Fix the issue
git add .
git commit -m "fix: resolve critical security vulnerability"

# Merge to main
git checkout main
git merge --no-ff hotfix/critical-bug-fix
git tag -a v1.2.1 -m "Hotfix version 1.2.1"

# Merge to develop
git checkout develop
git merge --no-ff hotfix/critical-bug-fix

# Push and clean up
git push origin main
git push origin develop
git push origin v1.2.1
git branch -d hotfix/critical-bug-fix
```

## Advanced Git Operations

### Merge Conflicts in MAUI Files
```bash
# For .csproj conflicts (common in MAUI)
git checkout --theirs MauiApp1/MauiApp1.csproj  # Take their version
# Then manually review and edit if needed

# For XAML conflicts
git mergetool  # Use configured merge tool
```

### Managing Large Files
```bash
# Install Git LFS for large assets
git lfs install
git lfs track "*.png"
git lfs track "*.jpg"
git lfs track "*.mp4"
git add .gitattributes
```

### Branch Cleanup
```bash
# List merged branches
git branch --merged develop

# Clean up local branches
git branch -d feature/completed-feature

# Clean up remote tracking branches
git remote prune origin
```