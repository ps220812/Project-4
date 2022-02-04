@extends('layouts.layout')
@section('title')
    {{ __('Homepage') }}
@endsection
@section('content')
    <body class="antialiased">
        <div>
            @foreach($pizzas as $pizza)
                <div style="margin: 10px">
                    {{$pizza->pizza_name}}
                </div>
            @endforeach
        </div>
    </body>
@endsection
