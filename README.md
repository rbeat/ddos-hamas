# DDOS HAMAS

## Requirements
- Ubuntu 20.04

## How to run?

Command:
`apt update -y &&  apt upgrade -y &&  apt install -y git libssl-dev screen &&  wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh &&  chmod +x ./dotnet-install.sh &&  ./dotnet-install.sh --channel 5.0 &&  git clone https://github.com/rbeat/ddos-hamas &&  cd ddos-hamas && screen -S ddos "/root/.dotnet/dotnet run"`