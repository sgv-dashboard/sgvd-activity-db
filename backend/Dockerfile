FROM rust:latest as builder
WORKDIR /usr/src/activity-db
COPY . .
RUN cargo install --path .


FROM debian:buster-slim
RUN apt-get update
COPY --from=builder /usr/local/cargo/bin/activity-db /usr/local/bin/activity-db
CMD ["activity-db"]