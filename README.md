# Avalonia ComboBox Bug Demo

This is a minimal Avalonia application that demonstrates a bug with the `ComboBox` control when using the **FluentTheme**.

## ❗ Bug Description

When using the default **FluentTheme**, the `ComboBox` fails to display the selected item correctly. The same code works fine when switching to the **SimpleTheme**.

When click on the arrow of the `ComboBox` (while using **FluentTheme**) the popup does not open to show the values.

The user could still change the values by using the mousewheel.

## ✅ Steps to Reproduce

1. Run the app.
2. A `ComboBox` with five items appears.
3. **Expected:** Clicking on the arrow of the ComboBox opens the list of items
4. **Actual:** Clicking the arrow of the ComboBox does not open the list of items

## 💡 Notes

- This issue **does not occur** when using the `SimpleTheme`.
- No data bindings are used — this is purely XAML-based item population.
- Changing the theme to SimpleTheme in `App.axaml` fixes the issue. (Comment out the FluentTheme if you do this)

## 🔁 How to Switch to SimpleTheme

To verify the bug disappears:
```App.axaml
<Application.Styles>
  <FluentTheme /> <!-- Replace this -->
  <!-- <SimpleTheme /> -->       <!-- With this -->
</Application.Styles>
