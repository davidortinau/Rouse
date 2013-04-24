Rouse
=====

Xamarin iOS Tweening Library inspired by every Flash animation library ever written.

Attempting to:
- make complex easing simple.
- abstract away the bizarro concepts of Core Animation. FillMode?

Example:

<pre>
Rouse.To( layer, 1, new KeyPaths{ PositionX = 120}, Easing.EaseOutExpo );
</pre>


Copyright 2013 Simply Profound <dave@simplyprofound.com>

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

 http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.