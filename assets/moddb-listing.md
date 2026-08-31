# YeetReborn - ModDB listing sheet

Fill-in sheet for https://mods.vintagestory.at/edit/mod
Assets referenced below live beside this file (mods/yeet-reborn/assets/).

## Core

| Field | Value | Status |
|---|---|---|
| Status | Published | LIVE |
| Category | Game Mod (Code Mod - modinfo type is `Code`) | ready |
| Tags | Utility, Fun, Meme, Humor | ready |
| Name | YeetReborn | ready |
| URL Alias | yeetreborn | ready |
| Summary (<=100 chars) | see below (100 chars - at the limit) | LIVE |
| Side | Universal | ready |

Side: the mod registers a client hotkey and a server packet handler, so it is
Universal. modinfo.json omits `side`, which already defaults to Universal.

Tags come from a fixed vocabulary (209 values) - see moddb-tags.txt. Free text
is not accepted. `Utility` is deliberate: it is the ONLY tag on the original
YEET (6951 downloads, 58 follows), so it is the discovery path for anyone who
remembers that mod.

## Summary (100 char limit)

Press a key (default: Y) to toss your selected item over the horizon! Ctrl+Y throws the whole stack.

## Description (rich text body)

Published. moddb-description.md records the live text.

WARNING: the ModDB "Text" field is TinyMCE rich text, NOT markdown. Pasting
markdown publishes literal asterisks and brackets. Apply bold/italic/links
with the editor toolbar.

## Links

| Field | Value |
|---|---|
| Homepage / Forum Post | none yet |
| Trailer Video | none |
| Source Code | https://github.com/FeistyFerretGames/YeetReborn |
| Issue tracker | https://github.com/FeistyFerretGames/YeetReborn/issues |
| Wiki | none |
| Donate | none |

## Images

| Asset | Size | Purpose |
|---|---|---|
| logo-480x480.png | 480x480 | ModDB logo (mod cards) |
| logo-480x320.png | 480x320 | External logo (social embeds) |
| modicon-source-crop.png | 410x410 | master crop, re-derive any size |
| ../release-image.png | 1333x1180 | original screenshot |

Both logos are cropped from the same in-game screenshot of a puff ring.

### Gotchas

- Logos are SELECTED FROM the Screenshots you upload. Upload all three
  (the two logos and any gallery shots), then mark which are logos.
- An image marked as a logo is REMOVED from the slideshow. If the puff-ring
  screenshot is the only upload and it becomes the logo, the gallery is empty.
  We need at least 2-3 more gameplay screenshots.
- Set BOTH logos explicitly. If only the 480x480 is set, ModDB derives the
  external logo from its UPPER 480x320 - which cuts the bottom off the ring.

## Outstanding

- [x] screenshots: screenshot01/02.png (1920x1080) - accepted as-is
- [x] pick a summary
- [x] write the description body
- [x] pick category + tags
- [x] source published: github.com/FeistyFerretGames/YeetReborn (public, MIT)
