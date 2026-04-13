# Scripts

## Folder Structure

```
Scripts/
├── Core/               # Pure, game-agnostic systems
│   ├── Observable/     # Observable<T> reactive value wrapper
│   ├── Pooling/        # Generic GameObject pooler
│   └── Provider/       # Lightweight service locator
│
├── Game/               # Game domain logic
│   ├── Content/        # Lockable/unlockable content definition
│   └── Currency/       # Currency types, rewards, and runtime service
│
└── UI/                 # Presentation layer only
    ├── Buttons/        # AButton base + concrete button types
    ├── Controllers/    # PopupController, TopBarController, BottomBarController
    ├── Extensions/     # CanvasGroup & RectTransform extension methods
    ├── Models/         # ScriptableObject data contracts consumed by views
    ├── Particles/      # UI particle effect providers
    ├── Utility/        # AdaptiveSafeArea
    └── Views/          # AView base + all concrete views & popups
```

---

## ScriptableObject Configuration

Most features are driven by ScriptableObjects, allowing designers to configure the game without touching code.

| Asset | Menu Path | Purpose |
|---|---|---|
| `Currency` | `Game/Economy/Currency` | Defines a currency type — key, icon, default amount, purchasable flag |
| `Content` | `Game/Content` | Defines a piece of lockable/unlockable content |
| `ScriptableObservableBoolean` | `Game/Core/ScriptableObservable/Boolean` | Persistent observable bool; survives scene loads, subscribable from anywhere |
| `TopBarData` | `Game/UI/TopBar` | List of `CurrencyBarData` assets shown in the top bar |
| `CurrencyBarData` | `Game/UI/CurrencyBar` | Binds a `Currency` to a bar slot; independently toggles particles on add/spend |
| `BottomBarData` | `Game/UI/BottomBar` | Ordered list of `BottomButtonData` assets that build the bottom nav bar |
| `BottomButtonData` | `Game/UI/Buttons/BottomButton` | Assigns an icon and target `Content` to a single bottom bar button |
| `SettingsOptionData` | `Game/UI/Settings/Option` | A basic settings row with a title and icon |
| `ToggleableSettingsOptionData` | `Game/UI/Settings/ToggleableOption` | Extends `SettingsOptionData`; links a row to a `ScriptableObservableBoolean` |
| `SettingsPopupData` | `Game/UI/Popup/Settings` | Composes a full settings popup — title, toggleable options, localization option |
| `LevelEndViewData` | `Game/UI/LevelEndView` | Defines big reward, small rewards list, and ad-bonus reward for the level end screen |

### How ScriptableObjects enable flexibility

- **New currency** — create a `Currency` asset, assign it to a `CurrencyBarData`, add that to a `TopBarData`. No code changes needed.
- **Reconfigure the bottom bar** — create/reorder `BottomButtonData` assets inside a `BottomBarData`. The bar rebuilds itself at runtime.
- **New settings toggle** — create a `ScriptableObservableBoolean` + `ToggleableSettingsOptionData`, wire them in the Inspector. The button auto-subscribes and reacts to state changes from anywhere in the codebase.
- **Level end rewards** — edit `LevelEndViewData` to adjust reward amounts and the ad-bonus reward without touching any MonoBehaviour.
- **Particle feedback per currency** — `CurrencyBarData`'s `ParticleOnAdd` / `ParticleOnSpend` flags let each currency independently opt in or out.

---

## Key Patterns

- **`Observable<T>` / `IObservable<T>`** — lightweight reactive values with `Subscribe` / `Unsubscribe`. Drives currency UI updates without tight coupling.
- **`ProviderService`** — static service locator; MonoBehaviours self-register on `Awake` and unregister on `OnDestroy`.
- **`AView` / `AButton`** — abstract base classes enforcing a consistent `Show`/`Hide` API and button-wiring pattern across all UI components.
- **`Pooler<T>`** — generic `Component` pool used by particle providers to avoid runtime allocations.
