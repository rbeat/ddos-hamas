# DDOS HAMAS

## Requirements
- Ubuntu 20.04

## How to run?

Command:
`apt update -y -q --force-yes &&  apt upgrade -y -q --force-yes &&  apt install -y -q --force-yes git libssl-dev screen &&  wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh &&  chmod +x ./dotnet-install.sh &&  ./dotnet-install.sh --channel 5.0 &&  git clone https://github.com/rbeat/ddos-hamas &&  cd ddos-hamas && screen /root/.dotnet/dotnet run`