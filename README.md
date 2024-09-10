# NuGet Package Template
This repository is a template for **Public C# Libraries** that will be published as **NuGet Packages**.

## Table of Contents
- [Setup](#setup)
- [Items](#items)

---
## Setup
1. Clone the repository
2. Rename `TJC.Rename` & `TJC.Rename.Tests` folders & `.csproj` files to the desired library name
  - Update the following `.csproj` file properties
	- Title
	- Description
	- RepositoryUrl
	- InternalsVisibleToAttribute
3. In `workflows` replace the `{REPLACE_ME}` placeholders
4. In the `README.md` delete everything above the `---` and add some initial documentation
5. Delete the [ruleset](.github/ruleset.json) (back it up somewhere locally for later)
6. Amend the initial commit & force push the changes using `git push -f`
7. ~~Set `GitHub NuGet Package` visibility to `public`~~
8. **Repository Settings**
  - Import repository permissions from the local backup of [ruleset](.github/ruleset.json)
  - **Pull Requests**
	- Disable `Allow merge commits`
	- Enable `Always suggest updating pull request branches`
	- Enable `Automatically delete head branches`
9. On **GitHub** deselect **Releases**, **Packages** & **Deployments**
10. On **GitHub** add a **Description**, **Website** link to [www.nuget.org/packages/TJC.LibraryName](https://www.nuget.org/packages/TJC.LibraryName) & **Topics**

---

[![NuGet Version and Downloads count](https://buildstats.info/nuget/TJC.LibraryName)](https://www.nuget.org/packages/TJC.LibraryName)

## Items
