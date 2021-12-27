FROM rust:latest

WORKDIR /usr/src/activity_db
COPY . .

RUN cargo install --path .

CMD ["activity-db"]