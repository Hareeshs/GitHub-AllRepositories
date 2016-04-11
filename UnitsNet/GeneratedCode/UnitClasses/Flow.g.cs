﻿// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/anjdreas/UnitsNet
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     In physics and engineering, in particular fluid dynamics and hydrometry, the volumetric flow rate, (also known as volume flow rate, rate of fluid flow or volume velocity) is the volume of fluid which passes through a given surface per unit time. The SI unit is m3·s−1 (cubic meters per second). In US Customary Units and British Imperial Units, volumetric flow rate is often expressed as ft3/s (cubic feet per second). It is usually represented by the symbol Q.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Flow : IComparable, IComparable<Flow>
    {
        /// <summary>
        ///     Base unit of Flow.
        /// </summary>
        private readonly double _cubicMetersPerSecond;

        public Flow(double cubicmeterspersecond) : this()
        {
            _cubicMetersPerSecond = cubicmeterspersecond;
        }

        #region Properties

        public static FlowUnit BaseUnit
        {
            get { return FlowUnit.CubicMeterPerSecond; }
        }

        /// <summary>
        ///     Get Flow in CentilitersPerMinute.
        /// </summary>
        public double CentilitersPerMinute
        {
            get { return (_cubicMetersPerSecond*60000.00000) / 1e-2d; }
        }

        /// <summary>
        ///     Get Flow in CubicFeetPerSecond.
        /// </summary>
        public double CubicFeetPerSecond
        {
            get { return _cubicMetersPerSecond*35.314666213; }
        }

        /// <summary>
        ///     Get Flow in CubicMetersPerHour.
        /// </summary>
        public double CubicMetersPerHour
        {
            get { return _cubicMetersPerSecond*3600; }
        }

        /// <summary>
        ///     Get Flow in CubicMetersPerSecond.
        /// </summary>
        public double CubicMetersPerSecond
        {
            get { return _cubicMetersPerSecond; }
        }

        /// <summary>
        ///     Get Flow in DecilitersPerMinute.
        /// </summary>
        public double DecilitersPerMinute
        {
            get { return (_cubicMetersPerSecond*60000.00000) / 1e-1d; }
        }

        /// <summary>
        ///     Get Flow in KilolitersPerMinute.
        /// </summary>
        public double KilolitersPerMinute
        {
            get { return (_cubicMetersPerSecond*60000.00000) / 1e3d; }
        }

        /// <summary>
        ///     Get Flow in LitersPerHour.
        /// </summary>
        public double LitersPerHour
        {
            get { return _cubicMetersPerSecond*3600000.00000; }
        }

        /// <summary>
        ///     Get Flow in LitersPerMinute.
        /// </summary>
        public double LitersPerMinute
        {
            get { return _cubicMetersPerSecond*60000.00000; }
        }

        /// <summary>
        ///     Get Flow in LitersPerSecond.
        /// </summary>
        public double LitersPerSecond
        {
            get { return _cubicMetersPerSecond*1000.00000; }
        }

        /// <summary>
        ///     Get Flow in MicrolitersPerMinute.
        /// </summary>
        public double MicrolitersPerMinute
        {
            get { return (_cubicMetersPerSecond*60000.00000) / 1e-6d; }
        }

        /// <summary>
        ///     Get Flow in MillilitersPerMinute.
        /// </summary>
        public double MillilitersPerMinute
        {
            get { return (_cubicMetersPerSecond*60000.00000) / 1e-3d; }
        }

        /// <summary>
        ///     Get Flow in MillionUsGallonsPerDay.
        /// </summary>
        public double MillionUsGallonsPerDay
        {
            get { return _cubicMetersPerSecond*22.824465227; }
        }

        /// <summary>
        ///     Get Flow in NanolitersPerMinute.
        /// </summary>
        public double NanolitersPerMinute
        {
            get { return (_cubicMetersPerSecond*60000.00000) / 1e-9d; }
        }

        /// <summary>
        ///     Get Flow in UsGallonsPerMinute.
        /// </summary>
        public double UsGallonsPerMinute
        {
            get { return _cubicMetersPerSecond*15850.323141489; }
        }

        #endregion

        #region Static

        public static Flow Zero
        {
            get { return new Flow(); }
        }

        /// <summary>
        ///     Get Flow from CentilitersPerMinute.
        /// </summary>
        public static Flow FromCentilitersPerMinute(double centilitersperminute)
        {
            return new Flow((centilitersperminute/60000.00000) * 1e-2d);
        }

        /// <summary>
        ///     Get Flow from CubicFeetPerSecond.
        /// </summary>
        public static Flow FromCubicFeetPerSecond(double cubicfeetpersecond)
        {
            return new Flow(cubicfeetpersecond/35.314666213);
        }

        /// <summary>
        ///     Get Flow from CubicMetersPerHour.
        /// </summary>
        public static Flow FromCubicMetersPerHour(double cubicmetersperhour)
        {
            return new Flow(cubicmetersperhour/3600);
        }

        /// <summary>
        ///     Get Flow from CubicMetersPerSecond.
        /// </summary>
        public static Flow FromCubicMetersPerSecond(double cubicmeterspersecond)
        {
            return new Flow(cubicmeterspersecond);
        }

        /// <summary>
        ///     Get Flow from DecilitersPerMinute.
        /// </summary>
        public static Flow FromDecilitersPerMinute(double decilitersperminute)
        {
            return new Flow((decilitersperminute/60000.00000) * 1e-1d);
        }

        /// <summary>
        ///     Get Flow from KilolitersPerMinute.
        /// </summary>
        public static Flow FromKilolitersPerMinute(double kilolitersperminute)
        {
            return new Flow((kilolitersperminute/60000.00000) * 1e3d);
        }

        /// <summary>
        ///     Get Flow from LitersPerHour.
        /// </summary>
        public static Flow FromLitersPerHour(double litersperhour)
        {
            return new Flow(litersperhour/3600000.00000);
        }

        /// <summary>
        ///     Get Flow from LitersPerMinute.
        /// </summary>
        public static Flow FromLitersPerMinute(double litersperminute)
        {
            return new Flow(litersperminute/60000.00000);
        }

        /// <summary>
        ///     Get Flow from LitersPerSecond.
        /// </summary>
        public static Flow FromLitersPerSecond(double literspersecond)
        {
            return new Flow(literspersecond/1000.00000);
        }

        /// <summary>
        ///     Get Flow from MicrolitersPerMinute.
        /// </summary>
        public static Flow FromMicrolitersPerMinute(double microlitersperminute)
        {
            return new Flow((microlitersperminute/60000.00000) * 1e-6d);
        }

        /// <summary>
        ///     Get Flow from MillilitersPerMinute.
        /// </summary>
        public static Flow FromMillilitersPerMinute(double millilitersperminute)
        {
            return new Flow((millilitersperminute/60000.00000) * 1e-3d);
        }

        /// <summary>
        ///     Get Flow from MillionUsGallonsPerDay.
        /// </summary>
        public static Flow FromMillionUsGallonsPerDay(double millionusgallonsperday)
        {
            return new Flow(millionusgallonsperday/22.824465227);
        }

        /// <summary>
        ///     Get Flow from NanolitersPerMinute.
        /// </summary>
        public static Flow FromNanolitersPerMinute(double nanolitersperminute)
        {
            return new Flow((nanolitersperminute/60000.00000) * 1e-9d);
        }

        /// <summary>
        ///     Get Flow from UsGallonsPerMinute.
        /// </summary>
        public static Flow FromUsGallonsPerMinute(double usgallonsperminute)
        {
            return new Flow(usgallonsperminute/15850.323141489);
        }


        /// <summary>
        ///     Get nullable Flow from nullable CentilitersPerMinute.
        /// </summary>
        public static Flow? FromCentilitersPerMinute(double? centilitersperminute)
        {
            if (centilitersperminute.HasValue)
            {
                return FromCentilitersPerMinute(centilitersperminute.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Flow from nullable CubicFeetPerSecond.
        /// </summary>
        public static Flow? FromCubicFeetPerSecond(double? cubicfeetpersecond)
        {
            if (cubicfeetpersecond.HasValue)
            {
                return FromCubicFeetPerSecond(cubicfeetpersecond.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Flow from nullable CubicMetersPerHour.
        /// </summary>
        public static Flow? FromCubicMetersPerHour(double? cubicmetersperhour)
        {
            if (cubicmetersperhour.HasValue)
            {
                return FromCubicMetersPerHour(cubicmetersperhour.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Flow from nullable CubicMetersPerSecond.
        /// </summary>
        public static Flow? FromCubicMetersPerSecond(double? cubicmeterspersecond)
        {
            if (cubicmeterspersecond.HasValue)
            {
                return FromCubicMetersPerSecond(cubicmeterspersecond.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Flow from nullable DecilitersPerMinute.
        /// </summary>
        public static Flow? FromDecilitersPerMinute(double? decilitersperminute)
        {
            if (decilitersperminute.HasValue)
            {
                return FromDecilitersPerMinute(decilitersperminute.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Flow from nullable KilolitersPerMinute.
        /// </summary>
        public static Flow? FromKilolitersPerMinute(double? kilolitersperminute)
        {
            if (kilolitersperminute.HasValue)
            {
                return FromKilolitersPerMinute(kilolitersperminute.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Flow from nullable LitersPerHour.
        /// </summary>
        public static Flow? FromLitersPerHour(double? litersperhour)
        {
            if (litersperhour.HasValue)
            {
                return FromLitersPerHour(litersperhour.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Flow from nullable LitersPerMinute.
        /// </summary>
        public static Flow? FromLitersPerMinute(double? litersperminute)
        {
            if (litersperminute.HasValue)
            {
                return FromLitersPerMinute(litersperminute.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Flow from nullable LitersPerSecond.
        /// </summary>
        public static Flow? FromLitersPerSecond(double? literspersecond)
        {
            if (literspersecond.HasValue)
            {
                return FromLitersPerSecond(literspersecond.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Flow from nullable MicrolitersPerMinute.
        /// </summary>
        public static Flow? FromMicrolitersPerMinute(double? microlitersperminute)
        {
            if (microlitersperminute.HasValue)
            {
                return FromMicrolitersPerMinute(microlitersperminute.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Flow from nullable MillilitersPerMinute.
        /// </summary>
        public static Flow? FromMillilitersPerMinute(double? millilitersperminute)
        {
            if (millilitersperminute.HasValue)
            {
                return FromMillilitersPerMinute(millilitersperminute.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Flow from nullable MillionUsGallonsPerDay.
        /// </summary>
        public static Flow? FromMillionUsGallonsPerDay(double? millionusgallonsperday)
        {
            if (millionusgallonsperday.HasValue)
            {
                return FromMillionUsGallonsPerDay(millionusgallonsperday.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Flow from nullable NanolitersPerMinute.
        /// </summary>
        public static Flow? FromNanolitersPerMinute(double? nanolitersperminute)
        {
            if (nanolitersperminute.HasValue)
            {
                return FromNanolitersPerMinute(nanolitersperminute.Value);
            }
            else
            {
            	return null;
            }
        }

        /// <summary>
        ///     Get nullable Flow from nullable UsGallonsPerMinute.
        /// </summary>
        public static Flow? FromUsGallonsPerMinute(double? usgallonsperminute)
        {
            if (usgallonsperminute.HasValue)
            {
                return FromUsGallonsPerMinute(usgallonsperminute.Value);
            }
            else
            {
            	return null;
            }
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="FlowUnit" /> to <see cref="Flow" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Flow unit value.</returns>
        public static Flow From(double value, FlowUnit fromUnit)
        {
            switch (fromUnit)
            {
                case FlowUnit.CentilitersPerMinute:
                    return FromCentilitersPerMinute(value);
                case FlowUnit.CubicFootPerSecond:
                    return FromCubicFeetPerSecond(value);
                case FlowUnit.CubicMeterPerHour:
                    return FromCubicMetersPerHour(value);
                case FlowUnit.CubicMeterPerSecond:
                    return FromCubicMetersPerSecond(value);
                case FlowUnit.DecilitersPerMinute:
                    return FromDecilitersPerMinute(value);
                case FlowUnit.KilolitersPerMinute:
                    return FromKilolitersPerMinute(value);
                case FlowUnit.LitersPerHour:
                    return FromLitersPerHour(value);
                case FlowUnit.LitersPerMinute:
                    return FromLitersPerMinute(value);
                case FlowUnit.LitersPerSecond:
                    return FromLitersPerSecond(value);
                case FlowUnit.MicrolitersPerMinute:
                    return FromMicrolitersPerMinute(value);
                case FlowUnit.MillilitersPerMinute:
                    return FromMillilitersPerMinute(value);
                case FlowUnit.MillionUsGallonsPerDay:
                    return FromMillionUsGallonsPerDay(value);
                case FlowUnit.NanolitersPerMinute:
                    return FromNanolitersPerMinute(value);
                case FlowUnit.UsGallonsPerMinute:
                    return FromUsGallonsPerMinute(value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="FlowUnit" /> to <see cref="Flow" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Flow unit value.</returns>
        public static Flow? From(double? value, FlowUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case FlowUnit.CentilitersPerMinute:
                    return FromCentilitersPerMinute(value.Value);
                case FlowUnit.CubicFootPerSecond:
                    return FromCubicFeetPerSecond(value.Value);
                case FlowUnit.CubicMeterPerHour:
                    return FromCubicMetersPerHour(value.Value);
                case FlowUnit.CubicMeterPerSecond:
                    return FromCubicMetersPerSecond(value.Value);
                case FlowUnit.DecilitersPerMinute:
                    return FromDecilitersPerMinute(value.Value);
                case FlowUnit.KilolitersPerMinute:
                    return FromKilolitersPerMinute(value.Value);
                case FlowUnit.LitersPerHour:
                    return FromLitersPerHour(value.Value);
                case FlowUnit.LitersPerMinute:
                    return FromLitersPerMinute(value.Value);
                case FlowUnit.LitersPerSecond:
                    return FromLitersPerSecond(value.Value);
                case FlowUnit.MicrolitersPerMinute:
                    return FromMicrolitersPerMinute(value.Value);
                case FlowUnit.MillilitersPerMinute:
                    return FromMillilitersPerMinute(value.Value);
                case FlowUnit.MillionUsGallonsPerDay:
                    return FromMillionUsGallonsPerDay(value.Value);
                case FlowUnit.NanolitersPerMinute:
                    return FromNanolitersPerMinute(value.Value);
                case FlowUnit.UsGallonsPerMinute:
                    return FromUsGallonsPerMinute(value.Value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="culture">Culture to use for localization. Defaults to Thread.CurrentUICulture.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(FlowUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Flow operator -(Flow right)
        {
            return new Flow(-right._cubicMetersPerSecond);
        }

        public static Flow operator +(Flow left, Flow right)
        {
            return new Flow(left._cubicMetersPerSecond + right._cubicMetersPerSecond);
        }

        public static Flow operator -(Flow left, Flow right)
        {
            return new Flow(left._cubicMetersPerSecond - right._cubicMetersPerSecond);
        }

        public static Flow operator *(double left, Flow right)
        {
            return new Flow(left*right._cubicMetersPerSecond);
        }

        public static Flow operator *(Flow left, double right)
        {
            return new Flow(left._cubicMetersPerSecond*(double)right);
        }

        public static Flow operator /(Flow left, double right)
        {
            return new Flow(left._cubicMetersPerSecond/(double)right);
        }

        public static double operator /(Flow left, Flow right)
        {
            return Convert.ToDouble(left._cubicMetersPerSecond/right._cubicMetersPerSecond);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Flow)) throw new ArgumentException("Expected type Flow.", "obj");
            return CompareTo((Flow) obj);
        }

        public int CompareTo(Flow other)
        {
            return _cubicMetersPerSecond.CompareTo(other._cubicMetersPerSecond);
        }

        public static bool operator <=(Flow left, Flow right)
        {
            return left._cubicMetersPerSecond <= right._cubicMetersPerSecond;
        }

        public static bool operator >=(Flow left, Flow right)
        {
            return left._cubicMetersPerSecond >= right._cubicMetersPerSecond;
        }

        public static bool operator <(Flow left, Flow right)
        {
            return left._cubicMetersPerSecond < right._cubicMetersPerSecond;
        }

        public static bool operator >(Flow left, Flow right)
        {
            return left._cubicMetersPerSecond > right._cubicMetersPerSecond;
        }

        public static bool operator ==(Flow left, Flow right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._cubicMetersPerSecond == right._cubicMetersPerSecond;
        }

        public static bool operator !=(Flow left, Flow right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._cubicMetersPerSecond != right._cubicMetersPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _cubicMetersPerSecond.Equals(((Flow) obj)._cubicMetersPerSecond);
        }

        public override int GetHashCode()
        {
            return _cubicMetersPerSecond.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(FlowUnit unit)
        {
            switch (unit)
            {
                case FlowUnit.CentilitersPerMinute:
                    return CentilitersPerMinute;
                case FlowUnit.CubicFootPerSecond:
                    return CubicFeetPerSecond;
                case FlowUnit.CubicMeterPerHour:
                    return CubicMetersPerHour;
                case FlowUnit.CubicMeterPerSecond:
                    return CubicMetersPerSecond;
                case FlowUnit.DecilitersPerMinute:
                    return DecilitersPerMinute;
                case FlowUnit.KilolitersPerMinute:
                    return KilolitersPerMinute;
                case FlowUnit.LitersPerHour:
                    return LitersPerHour;
                case FlowUnit.LitersPerMinute:
                    return LitersPerMinute;
                case FlowUnit.LitersPerSecond:
                    return LitersPerSecond;
                case FlowUnit.MicrolitersPerMinute:
                    return MicrolitersPerMinute;
                case FlowUnit.MillilitersPerMinute:
                    return MillilitersPerMinute;
                case FlowUnit.MillionUsGallonsPerDay:
                    return MillionUsGallonsPerDay;
                case FlowUnit.NanolitersPerMinute:
                    return NanolitersPerMinute;
                case FlowUnit.UsGallonsPerMinute:
                    return UsGallonsPerMinute;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        #region Parsing

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="formatProvider">Format to use when parsing number and unit. If it is null, it defaults to <see cref="NumberFormatInfo.CurrentInfo"/> for parsing the number and <see cref="CultureInfo.CurrentUICulture"/> for parsing the unit abbreviation by culture/language.</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;". Eg. "5.5 m" or "1ft 2in"
        /// </exception>
        /// <exception cref="AmbiguousUnitParseException">
        ///     More than one unit is represented by the specified unit abbreviation.
        ///     Example: Volume.Parse("1 cup") will throw, because it can refer to any of
        ///     <see cref="VolumeUnit.MetricCup" />, <see cref="VolumeUnit.UsLegalCup" /> and <see cref="VolumeUnit.UsCustomaryCup" />.
        /// </exception>
        /// <exception cref="UnitsNetException">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref="UnitsNetException" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        public static Flow Parse(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = string.Format(@"[\d., {0}{1}]*\d",  // allows digits, dots, commas, and spaces in the quantity (must end in digit)
                            numFormat.NumberGroupSeparator,    // adds provided (or current) culture's group separator
                            numFormat.NumberDecimalSeparator); // adds provided (or current) culture's decimal separator
            var exponentialRegex = @"(?:[eE][-+]?\d+)?)";
            var regexString = string.Format(@"(?:\s*(?<value>[-+]?{0}{1}{2}{3})?{4}{5}",
                            numRegex,                // capture base (integral) Quantity value
                            exponentialRegex,        // capture exponential (if any), end of Quantity capturing
                            @"\s?",                  // ignore whitespace (allows both "1kg", "1 kg")
                            @"(?<unit>[^\s\d,]+)",   // capture Unit (non-whitespace) input
                            @"(and)?,?",             // allow "and" & "," separators between quantities
                            @"(?<invalid>[a-z]*)?"); // capture invalid input

            var quantities = ParseWithRegex(regexString, str, formatProvider);
            if (quantities.Count == 0)
            {
                throw new ArgumentException(
                    "Expected string to have at least one pair of quantity and unit in the format"
                    + " \"&lt;quantity&gt; &lt;unit&gt;\". Eg. \"5.5 m\" or \"1ft 2in\"");
            }
            return quantities.Aggregate((x, y) => x + y);
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<Flow> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Flow>();

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;

                var valueString = groups["value"].Value;
                var unitString = groups["unit"].Value;
                if (groups["invalid"].Value != "")
                {
                    var newEx = new UnitsNetException("Invalid string detected: " + groups["invalid"].Value);
                    newEx.Data["input"] = str;
                    newEx.Data["matched value"] = valueString;
                    newEx.Data["matched unit"] = unitString;
                    newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                    throw newEx;
                }
                if (valueString == "" && unitString == "") continue;

                try
                {
                    FlowUnit unit = ParseUnit(unitString, formatProvider);
                    double value = double.Parse(valueString, formatProvider);

                    converted.Add(From(value, unit));
                }
                catch(AmbiguousUnitParseException ambiguousException)
                {
                    throw;
                }
                catch(Exception ex)
                {
                    var newEx = new UnitsNetException("Error parsing string.", ex);
                    newEx.Data["input"] = str;
                    newEx.Data["matched value"] = valueString;
                    newEx.Data["matched unit"] = unitString;
                    newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                    throw newEx;
                }
            }
            return converted;
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static FlowUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<FlowUnit>(str.Trim());

            if (unit == FlowUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized FlowUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is CubicMeterPerSecond
        /// </summary>
        public static FlowUnit ToStringDefaultUnit { get; set; } = FlowUnit.CubicMeterPerSecond;

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(ToStringDefaultUnit);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(FlowUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
        {
            return ToString(unit, culture, UnitFormatter.GetFormat(As(unit), significantDigitsAfterRadix));
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(FlowUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
