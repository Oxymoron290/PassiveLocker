# Ford Passive Door Locker

## Overview

My 2020 Ford F-150 has been ransacked multiple times in the few short months I've had it. Some of my family members have a bad habit of not locking the vehicle when they are done with it, affording criminals the opportunity. My Ford came with a mobile app called [FordPass](https://owner.ford.com/fordpass.html) which allows me to lock, unlock, start and stop the vehicle remotely. The `Ford.Pass.Connect` project hooks into that mobile app's API and allows me to issue the same commands from a computer. The PassiveLocker is a console app which issues the Lock command and waits for it to succeed. It can be setup as a scheduled task.

## TODO

- [ ] Improve Authentication and check for valid auth token.
- [ ] Add ability to only passive lock when vehicle is located in a certain geofence.
- [ ] Distribute `Ford.Pass.Connect` as nuget package
- [ ] Refactor `Ford.Pass.Connect` once the [new api is released](https://developer.ford.com/Forums/Topics/Detail/3fb6f055-3939-4c68-a741-2c26024a6168?name=rest%20APIs&page=0#msgb251277f-f302-45e0-adcf-0d61247b7920).

## Contributions

Much thanks to [@d4v3y0rk](https://d4v3y0rk.com/) for their work on [ffpass-module](https://github.com/d4v3y0rk/ffpass-module/) which helped speed this project along tremendously. I've very grateful for you.

## LICENSE

See [LICENSE](./LICENSE)
