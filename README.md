# **SHADOW TRANSFORM**

Unity3D editor asset for easy saving multiple positions for an object. Read a longer and more complex version of this document in Docs folder.

**Contents**

[What is…?](#_Toc502515148)

[How to install?](#_Toc502515149)

[How to use?](#_Toc502515150)

[Applications of asset](#_Toc502515151)

[Limitations](#_Toc502515152)

[Special thanks](#_Toc502515154)

[Contacts](#_Toc502515155)

# What is…?

When you make a game, it's always necessary to make some tweaks on your levels. Let's move that rock 3 units left and watch how gameplay has changed. Later, after a week of tests, you've decided that it's too bad. So, let's return it back to a previous position.

_...does anybody remember where **exactly** _that rock was?_

**ShadowTransform** is a tool to make process of creation and tweaking your levels more comfortable. It will **remember previous positions** for any of your objects and let you switch between them in one click.

Also, that's a great tool for gameplay testing, temporary level re-planning or a massive A/B testing.

# Applications of asset

When ShadowTransform may come in handy many ways, our asset way made with that in mind:

- **Play-testing for particular places of the map** – just make a state before each of part of the level.

- **Saving object's states before changes** – make an experiment, then switch to old state, then return to new and compare.

- **A/B testing** – hold all variants in one scene, and just switch between them.

# How to install?

Installation process is kinda trivial:

**If you've got a version of this asset from Unity Store or GitHub, you should import Unity's «Standard Assets» package first!**
You'll need **«Cameras», «Characters», «Effects»** and **«Particle Systems»** parts to make tutorial work. If you don't have one, get it from [Asset Store](https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-32351).
**If you've downloaded a package from https://madnesstudio.ru/ site, it's already inside.**

After this (for GitHub version) just place contents of Assets/ShadowTransform folder into your project's folder.

#

# How to use?
Check Docs folder for a ReadMe file.

# Limitations

ShadowTranform **may not** work correctly when you try to save state of:

- **Object with non-uniform scaling & rotation** – Unity hates non-uniform scaling together with rotation. Any object distorts and became an ugly mess. Collider goes insane. So, try not to use it at all, but if you need this badly – just remember, ShadowTransform may not work great with them.
- **Very large and very far objects** – if you decide to make something at the limit of floating point precision, ShadowTransform may not work properly.

Asset is free for any legal usage, commercial and non-commercial. But, **if you like it a lot** , please list it somewhere in your game's credits – and mail me. That would be a great news for me! :)

**This asset is distributed «AS IS» and WITHOUT ANY WARRANTY.**

Some license conditions may vary in future.

# Special thanks

- Users **MadDocPrime** , **Samana** , **Lawsonilka** for advices and testing my asset.
- **Unity Technologies** for their Standard Assets _(used in demo resources)_.
- All of my friends and those who are dear to me.

# Contacts

![](RackMultipart20230115-1-6sq0n_html_c952ebd0255fccb5.jpg)

**ShadowTransform** developed by **Ivan Klenov** (aka Wolf4D).

Madness Studio, 2018 г.

All rights reserved (C).

If you need any help, wanna make a proposal, need some advice or want to employ me, feel free to e-mail me:

[**Wolf4D@list.ru**](mailto:Wolf4D@list.ru)

# _Thanks for using ShadowTransform!_

## **Version 1.0**
