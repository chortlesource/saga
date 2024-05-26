# Saga
---
## Description

Saga is a personal project to build a library with the essential building blocks for a simple 2D game. It sits on top of MonoGame and provides a solid set of tools, abstracting much of the low level work.

It is heavily influenced by the [nez](https://github.com/prime31/Nez) framework by [prime31](https://github.com/prime31) but is sufficiently distinct to be considered more than a fork.

## Dependencies

* MonoGame >= 3.8.1
* .NET >= 2.0.3

## Installation (MSVC)

This represents a personal project that is very much in development. I have a full time academic job and updates are likely to be sparse. In all honesty I would advise against using it given [nez](https://github.com/prime31/Nez) is likely more complete and relevant to your needs as a developer.

If you would like to have a play you will need to do the following:

1. create a `Monogame Cross Platform Desktop Project`
2. clone or download the Saga repository and extract the files
3. Right click your *solution* in MSVC Add >> Existing Project, then navigate to where you unpacked Saga selecting `Saga.csproj`
4. Right click your *project* in MSVC Add >> Project Reference, then ensure that the box next to Saga is ticked

Saga should then build alongside your personal project.

## License

Unless otherwise specified the software is distributed under the MIT license outlined below.

Copyright (c) 2025 C. M. Short

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software:

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
