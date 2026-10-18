# Overparity

A 2D Unity game made by a small team over about ten weeks in fall 2019. This repository is the complete project as it stood at the end: 178 commits, from 2019-09-12 to 2019-11-22.

**[Watch the boss demo on YouTube](https://www.youtube.com/watch?v=La7ULaxWj1A)**

## Status

Archived. This is a historical snapshot and is not maintained. The code is jam-era team code, kept as it was.

## What's in the game

The playable build is a linear sequence of scenes, in build order:

1. `BackAssStory` - opening scene
2. `MENU` - main menu
3. `TutorialScene`
4. `PreLevelCutscene`
5. `Level_1`
6. `Level_2`
7. `Level_3`
8. `BOSS`
9. `Victory`

Enemies, bosses and the player are animated from sprite sequences. Systems built for the game include:

- **Dialogue**: text files converted into dialogue sequences, with character info, interaction triggers and animation events (`WaterKat/LocalDialogue`)
- **Input**: a custom input manager with scriptable input actions and an on-screen controller test (`WaterKat/Scripts/Input`)
- **Inventory** and **save stations** (`WaterKat/Inventory`, `WaterKat/SaveStation`)
- **Audio manager** with the game's sound effects and music (`WaterKat/AudioManager`)
- **2D room shadows and lighting** (`WaterKat/RoomShadow2D`, `WaterKat/Lighting2D.cs`)
- **Enemy AI** built on a finite state machine, plus scripted boss fights (`TESTING/Enemies/Scripts`)

## Running it

- Unity version: **2018.4.8f1** (see `ProjectSettings/ProjectVersion.txt`)
- Open the repository root as a Unity project. Newer Unity versions will offer to upgrade it, and some APIs may need changes.
- To play the full game, open `Assets/TESTING/Scenes/BackAssStory.unity` (the first scene in the build settings) and press Play.

## Repository layout

The `Assets` folder is organized by contributor, which is how the team worked, and one folder doubles as the integrated game.

| Folder | What it is |
| --- | --- |
| `Assets/TESTING` | The integrated game: all the scenes in the build, plus the enemies, player, levels, tutorial and dialogue content they use. Despite the name, this is the real game. |
| `Assets/WaterKat` | Engine-side systems (dialogue, input, audio, inventory, saves, lighting) and experimental scenes |
| `Assets/GaiusBrutusAfricanus` | Enemy and player prefabs, animations and sprites, with a sandbox scene (`GBASample`) |
| `Assets/Kaede` | Art, level backgrounds and the opening storyboard, with a sandbox scene (`KSample`) |
| `Assets/JordanHall` | Contributor sandbox (`JHSample`) |
| `Assets/Dien` | Level art and the main menu script |

Some art exists in more than one folder because contributors worked in their own areas and copied finished assets into `TESTING`. A few sandbox scenes and their assets are not part of the final build.

## Team

Commit authors, by number of commits: WaterKat, MouseMan2, deendduong, truonghjy. The contributor folders under `Assets` suggest others contributed art and content as well.

## Notes

- The Unity project name is `VGDAFALL2019`.
- There is no license file in this repository.
