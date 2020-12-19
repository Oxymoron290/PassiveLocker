# Ford Passive Door Locker

## Overview

My 2020 Ford F-150 has been ransacked multiple times in the few short months I've had it. Some of my family members have a bad habit of not locking the vehicle when they are done with it, affording criminals the opportunity. My Ford came with a mobile app called [FordPass](https://owner.ford.com/fordpass.html) which allows me to lock, unlock, start and stop the vehicle remotely. The Ford.Pass.Connect project hooks into that mobile app's API and allows me to issue the same commands from a computer. The PassiveLocker is a console app which issues the Lock command and waits for it to succeed. It can be setup as a scheduled task.

## TODO

- [ ] Improve Authentication and check for valid auth token.
- [ ] Add ability to only passive lock when vehicle is located in a certain geofence.

## LICENSE

See [LICENSE](./LICENSE)
